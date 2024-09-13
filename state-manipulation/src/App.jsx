import { useState, useEffect, useReducer } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'

const TYPES = {
  increment: Symbol(),
  decrement: Symbol(),
  reset: Symbol(),
  interval: Symbol(),
}

const reducer = (state, action) => {
  const { type, payload } = action

  switch (type) {
    case TYPES.increment:
    return state + payload
    case TYPES.decrement:
      return state - payload
    case TYPES.reset: 
    return 0
  
    default:
      return state
  }
}

function App() {
  const [count, setCount] = useState(0)
  const [interval, setInterval] = useState(0)

  const [state, dispatch] = useReducer(reducer, count)

  const handleReset = () => {
    dispatch({type: TYPES.reset})
  }

  const handleDecrement = () => {
    dispatch({type: TYPES.decrement, payload: interval})
  }

  const handleIncrement = () => {
    dispatch({type: TYPES.increment, payload: interval})
  }

  useEffect(() => {
    document.title = "Count: " + count
  }, [count])


  const handleInterval = ({ target }) => {
    const { value } = target
    setInterval(Number(value))
  }

  return (
    <>
      <div>
        <a href="https://vitejs.dev" target="_blank">
          <img src={viteLogo} className="logo" alt="Vite logo" />
        </a>
        <a href="https://react.dev" target="_blank">
          <img src={reactLogo} className="logo react" alt="React logo" />
        </a>
      </div>
      <h1>{state}</h1>
      <label htmlFor="aumento">Intervalo </label>
      <input type="text" name="aumento" id="aumento" onChange={handleInterval} />
      <div className="card">
        <button onClick={handleIncrement}>
          Incrementar
        </button>
        <button onClick={handleDecrement}>
          Decrementar
        </button>
        <button onClick={handleReset}>
          Resetear
        </button>
        <p>
          Edit <code>src/App.jsx</code> and save to test HMR
        </p>
      </div>
      <p className="read-the-docs">
        Click on the Vite and React logos to learn more
      </p>
    </>
  )
}

export default App
