import { IMovieBase } from "./IMovieBase";
import { IRating } from "./IRating";

export interface IMovieModel extends IMovieBase {
  rated: string;
  released: string;
  runtime: number;
  director: string;
  writer: string;
  actors: string;
  plot: string;
  language: string;
  country: string;
  awards: string;
  imdbRating: string;
  ratings: Array<IRating>;
}
