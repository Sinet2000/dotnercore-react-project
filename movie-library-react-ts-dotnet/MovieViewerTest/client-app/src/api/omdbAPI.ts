import { requestManager } from "api/client";
import { IFoundMovieByTitleModel, IMovieModel } from "common/types";

export const omdbAPI = {
  getByTitle: (title: string): Promise<IFoundMovieByTitleModel> =>
    requestManager.get("movie/getByTitle", { params: { title } }),
  getByImdbID: (imdbID: string, queryId: number): Promise<IMovieModel> =>
    requestManager.get("movie/getByImdbID", { params: { imdbID, queryId } }),
};
