//MIRAR VERCEL.JSON: SIRVE PARA QUE EL 404 SE MUESTRE Y FUNCIONE ADECUADAMENTE AL HACER DEPLOY EN VERCEL

import { Router, Route, Link, Switch } from "wouter"
import Listofanimals from "./components/List-of-animals"
import { Animaldetail } from "./components/Animal-detail"

const App = () => {
  return (
    <Switch>
      <Route path="/">
        <h1>Bienvenido!</h1>
        <Link to="/animals">Ir a animales 🐼</Link>
      </Route>
      <Route path="/animals" component={Listofanimals}></Route>
      <Route path="/animals/:id" component={Animaldetail} />

      <Route path="/*">
        <h1>404 not found</h1>
        <Link to="/">Volver ⬅</Link>
      </Route>
    </Switch>
  )
}

export default App
