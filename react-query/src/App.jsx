import { QueryClient, QueryClientProvider } from '@tanstack/react-query'
import PostApp from './components/PostApp';
import { ReactQueryDevtools } from '@tanstack/react-query-devtools';
import { Toaster } from 'sonner';

const queryClient = new QueryClient();

export default function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <Toaster richColors expand position='top-center' />
      <PostApp />
      <ReactQueryDevtools initialIsOpen={false} />
    </QueryClientProvider>
  )
}