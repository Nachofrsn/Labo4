import { useId } from "react"

export const TimeUnits = ({ label, value, onChange, name }) => {
  const id = useId()

  return (
    <div className='input-container'>
      <label htmlFor={id}>{label} </label>
      <input type="number" id={id} name={name} value={value} onChange={({ target }) => onChange(name, parseFloat(target.value))} />
    </div>
  )
}

