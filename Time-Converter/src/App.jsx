import { useReducer } from 'react'
import '../TimeConverter.css'
import { TimeUnits } from './components/TimeUnits'

function App() {
  const initialState = {
    hours: 0,
    minutes: 0,
    seconds: 0,
  }

  const [state, dispatch] = useReducer(timeReducer, initialState)

  const handleTimeChange = (type, value) => dispatch({type, value})
  
  return (
      <section className='time-converter'>
        <h2>Time converter</h2>
        <TimeUnits label="Horas: " name={TYPES.HOURS} value={isNaN(state.hours) ? "" : state.hours} onChange={handleTimeChange}/>
        <TimeUnits label="Minutes: " name={TYPES.MINUTES} value={isNaN(state.minutes) ? "" : state.minutes} onChange={handleTimeChange}/>
        <TimeUnits label="Seconds:" name={TYPES.SECONDS} value={isNaN(state.seconds) ? "" : state.seconds} onChange={handleTimeChange}/>
      </section>
  )
}

export default App

const TYPES = {
  HOURS: "hours",
  MINUTES: "minutes",
  SECONDS: "seconds",
}

function timeReducer(state, action) {
  const {type, value} = action

  switch (type) {
    case TYPES.HOURS:
      //EL RETURN DEBE SER DEL MISMO TIPO DE DATO QUE EL INITIAL STATE
      return {
        ...state,
        hours: value,
        minutes: value * 60,
        seconds: value * 3600,
      }
    
    case TYPES.MINUTES:
      return {
        ...state,
        hours: value / 60,
        minutes: value,
        seconds: value * 60
      }

    case TYPES.SECONDS: 
      return {
        ...state,
        hours: value / 3600,
        minutes: value / 60,
        seconds: value,
      }

    default: 
      return state
  }
}
