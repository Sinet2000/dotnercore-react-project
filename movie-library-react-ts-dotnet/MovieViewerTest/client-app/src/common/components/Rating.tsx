import { IRating } from "common/types";

type Props = {
  rating: IRating;
};

export const Rating = ({ rating }: Props) => {
  return (
    <div className="card border-primary mb-3">
      <div className="card-header">Rating</div>
      <div className="card-body text-primary">
        <h5 className="card-title">{rating.source}</h5>
        <p className="card-text">{rating.value}</p>
      </div>
    </div>
  );
};
