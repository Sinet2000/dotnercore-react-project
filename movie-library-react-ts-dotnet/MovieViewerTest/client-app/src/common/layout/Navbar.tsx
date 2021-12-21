import { Routes } from "app/routes";
import { Link } from "react-router-dom";

export const Navbar = () => {
  return (
    <nav className="navbar navbar-expand navbar-dark bg-dark">
      <Link to={Routes.Home} className="navbar-brand">
        MovieViewer
      </Link>
      <div className="navbar-nav mr-auto">
        <li className="nav-item">
          <Link to={Routes.Movies} className="nav-link">
            Movies
          </Link>
        </li>
      </div>
    </nav>
  );
};
