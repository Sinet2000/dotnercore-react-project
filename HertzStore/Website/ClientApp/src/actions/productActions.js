import axios from "axios"

export const GET_ALL_PRODUCTS_REQUEST = 'GET_ALL_PRODUCTS_REQUEST';
export const GET_ALL_PRODUCTS_SUCCESS = 'GET_ALL_PRODUCTS_SUCCESS';
export const GET_ALL_PRODUCTS_ERROR = 'GET_ALL_PRODUCTS_ERROR';

const getProductsSuccess = payload => ({
    type: GET_ALL_PRODUCTS_SUCCESS,
    payload
});

const getProductsError = payload => ({
    type: GET_ALL_PRODUCTS_ERROR,
    payload
});

export const getAllProducts = () => dispatch => {
    dispatch({ type: GET_ALL_PRODUCTS_REQUEST });
    return axios.get('api/product/getProducts').then(res => {
        const response = res.data;
        dispatch(getProductsSuccess(response));
    }).catch(error => {
        dispatch(getProductsError("Something went wrong!"));
        return Promise.reject({});
    })
}