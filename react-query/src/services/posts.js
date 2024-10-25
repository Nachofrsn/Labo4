import axios from "axios";

const { VITE_API_URL: apiUrl } = import.meta.env;

export const getAllPosts = async () => {
    const { data } = await axios.get(apiUrl)
    return data
}

export const createPost = async (newPost) => {
    const { data } = await axios.post(apiUrl, newPost)
    return data
}

export const updatePost = async ({ id, post }) => {
    const { data } = await axios.put(`${apiUrl}/${id}`, post)
    return data
}

export const deletePost = async (id) => {
    const { data } = axios.delete(`${apiUrl}/${id}`)
    return data
}