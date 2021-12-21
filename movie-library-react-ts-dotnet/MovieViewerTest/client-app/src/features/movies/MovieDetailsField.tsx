import { IMovieModel } from "common/types";
import { SecondaryText } from "common/components";

type Props = {
  label: string;
  content: React.ReactNode;
};

export const MovieDetailsField = ({ label, content }: Props) => {
  return (
    <div className="row">
      <SecondaryText className="col-sm-2">{label}</SecondaryText>
      <div className="col-sm-10">{content}</div>
    </div>
  );
};
