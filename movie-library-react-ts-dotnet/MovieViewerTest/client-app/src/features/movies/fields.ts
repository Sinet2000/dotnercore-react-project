import { IMovieModel } from "common/types";

type Field = {
  field: keyof IMovieModel;
  label: string;
};

export const fields: Array<Field> = [
  { field: "year", label: "Year" },
  { field: "genre", label: "Genre" },
  { field: "rated", label: "Rated" },
  { field: "released", label: "Released" },
  { field: "runtime", label: "Runtime" },
  { field: "director", label: "Director" },
  { field: "writer", label: "Writer" },
  { field: "actors", label: "Director" },
  { field: "plot", label: "Plot" },
  { field: "language", label: "Language" },
  { field: "awards", label: "Awards" },
  { field: "imdbRating", label: "IMDb Rating" },
];
