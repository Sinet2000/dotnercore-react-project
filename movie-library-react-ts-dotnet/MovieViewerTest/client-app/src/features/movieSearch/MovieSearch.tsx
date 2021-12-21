import { ChangeEvent, KeyboardEvent, useEffect, useRef, useState } from "react";
import { useHistory } from "react-router-dom";

type Props = {
  initialSearchQuery: string | null;
};

export const MovieSearch = ({ initialSearchQuery }: Props) => {
  const history = useHistory();
  const [searchQuery, setSearchQuery] = useState<string>(
    initialSearchQuery ?? ""
  );
  const searchInputRef = useRef<HTMLInputElement | null>(null);

  useEffect(() => {
    searchInputRef.current?.focus();
  }, []);

  const handleQueryChange = (event: ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
  };

  const handleEnterKey = (event: KeyboardEvent<HTMLInputElement>) => {
    if (event.key !== "Enter") return;

    handleSearch();
  };

  const handleSearch = () => {
    if (!searchQuery) return;

    const encodedURI = encodeURI(searchQuery);
    history.push(`/movies?q=${encodedURI}`);
  };

  return (
    <div className="row">
      <div className="col-md-6">
        <div className="input-group mb-3">
          <input
            ref={searchInputRef}
            type="text"
            className="form-control"
            placeholder="Search by title"
            value={searchQuery}
            onChange={handleQueryChange}
            onKeyUp={handleEnterKey}
          />
          <div className="input-group-append">
            <button
              className="btn btn-outline-secondary"
              type="button"
              onClick={handleSearch}
            >
              Search
            </button>
          </div>
        </div>
      </div>
    </div>
  );
};
