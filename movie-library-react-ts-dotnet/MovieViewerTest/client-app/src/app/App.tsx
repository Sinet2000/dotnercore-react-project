import "bootstrap/dist/css/bootstrap.min.css";

import { Switch, Route } from "react-router-dom";
import { MoviesPage } from "features/movies";
import { Navbar } from "common/layout";
import { Routes } from "./routes";

const App = () => {
  return (
    <div className="app">
      <Navbar />
      <div className="container mt-3">
        <Switch>
          <Route
            exact
            path={[Routes.Home, Routes.Movies]}
            component={MoviesPage}
          />
        </Switch>
      </div>
    </div>
  );
};

export default App;
