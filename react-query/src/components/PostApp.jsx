import { useState } from 'react'
import { useMutation, useQuery, useQueryClient } from '@tanstack/react-query'
import { createPost, deletePost, getAllPosts, updatePost } from '../services/posts'
import { toast } from 'sonner'

export const PostApp = () => {
    const [NewPost, setNewPost] = useState({
        title: "",
        body: ""
    })

    const queryClient = useQueryClient()

    const { data: posts, isLoading, error } = useQuery({
        queryKey: ["posts"],
        queryFn: getAllPosts,
    })

    const mutationCreatePost = useMutation({
        mutationKey: ["posts", "create"],
        mutationFn: createPost,
        onSuccess: (data) => {
            toast.success(`Post created ${JSON.stringify(data)}`)
            queryClient.invalidateQueries("posts")
        },
        onError: () => toast.error("Something went wrong :( "),
    })

    const mutationUpdatePost = useMutation({
        mutationKey: ["posts", "update"],
        mutationFn: updatePost,
        onSuccess: (data) => {
            toast.success(`Post updated ${JSON.stringify(data)}`)
            queryClient.invalidateQueries("posts")
        },
        onError: () => toast.error("Something went wrong :( "),
    })

    const mutationDeletePost = useMutation({
        mutationKey: ["posts", "delete"],
        mutationFn: deletePost,
        onSuccess: (data) => {
            toast.success(`Post deleted`)
            queryClient.invalidateQueries("posts")
        },
        onError: () => toast.error("Something went wrong :( "),
    })

    const handleAddPost = (e) => {
        e.preventDefault()
        if (NewPost.title && NewPost.body) {
            mutationCreatePost.mutate(NewPost)
            setNewPost({
                title: "",
                body: ""
            })
        }
    }

    const handleUpdatePost = (id) => {
        const updatedPost = { title: "Updated Title", body: "Updated Body" }
        mutationUpdatePost.mutate({ id, post: updatedPost })
    }

    const handleDeletePost = (id) => {
        mutationDeletePost.mutate(id)
    }

    const handleChange = (e) => {
        setNewPost({
            ...NewPost,
            [e.target.name]: e.target.value
        })
    }

    if (isLoading) return <p>Loading...</p>
    if (error) return <p>Error fetching posts</p>

    return (
        <div>
            <h1>Posts App</h1>
            <form onSubmit={handleAddPost}>
                <input type="text" name="title" placeholder="Post Title" value={NewPost.title} onChange={e => handleChange(e)} />
                <textarea name="body" placeholder="Post Body" value={NewPost.body} onChange={e => handleChange(e)}></textarea>
                <button type='submit'>Add Post</button>
            </form>

            <h2>Posts List</h2>
            <ul>
                {posts.map(p => {
                    return (
                        <li key={p.id}>
                            <h3>{p.title}</h3>
                            <p>{p.body}</p>
                            <button onClick={() => handleUpdatePost(p.id)}>Update</button>
                            <button onClick={() => handleDeletePost(p.id)}>Delete</button>
                        </li>
                    )
                })}
            </ul>
        </div>
    )
}

export default PostApp
