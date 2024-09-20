//DEBERIA IR EN CARPETA "PAGES"
import { Link } from 'wouter'
import { animals } from "../data"

export default function Listofanimals() {
    return (
        <>
            <Link to='/'>Volver a la pagina principal</Link>
            <h2>Lista de animales:</h2>
            <ul style={{ listStyle: "none", padding: 0 }}>
                {animals.map(a => {
                    return (
                        <li key={a.id}>
                            <Link to={`/animals/${a.id}`}>{a.name}</Link>
                        </li>
                    )
                })}
            </ul>
        </>
    )
}

