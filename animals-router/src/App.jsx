//MIRAR VERCEL.JSON: SIRVE PARA QUE EL 404 SE MUESTRE Y FUNCIONE ADECUADAMENTE AL HACER DEPLOY EN VERCEL

import { Router, Route, Link, Switch } from "wouter"
import { Suspense } from "react"
//import Listofanimals from "./components/List-of-animals"
//import { Animaldetail } from "./components/Animal-detail"

const AnimalDetailPage = lazy(() => import("./components/Animal-detail"))
const ListOfAnimalsPage = lazy(() => import("./components/List-of-animals"))

const App = () => {
  return (
    <Switch>
      <Route path="/">
        <h1>Bienvenido!</h1>
        <Link to="/animals">Ir a animales 🐼</Link>
      </Route>
      <Suspense fallback={<h1>Cargando lista...</h1>}>
        <Route path="/animals" component={ListOfAnimalsPage}></Route>
      </Suspense>
        <Route path="/animals/:id" component={AnimalDetailPage} />

      <Route path="/*">
        <h1>404 not found</h1>
        <Link to="/">Volver ⬅</Link>
      </Route>
    </Switch>
  )
}

export default App
