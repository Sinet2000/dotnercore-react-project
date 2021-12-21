import { combineReducers } from "redux";
import productReducers from "./productReducers";

const rootReducer = combineReducers({
    products: productReducers
});

export default rootReducer;