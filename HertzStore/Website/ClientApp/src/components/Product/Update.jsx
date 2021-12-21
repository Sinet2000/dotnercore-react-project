import React, { Component } from "react";
import axios from "axios";
import { validation, priceExpression } from '../../helpers/';

export class Update extends Component {
    constructor(props) {
        super(props);

        this.onUpdateCancel = this.onUpdateCancel.bind(this);
        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            id: null,
            name: '',
            sku: '',
            price: 0.00,
            count: 0,
            imageLink: '',
            error: {
                name: '',
                sku: '',
                price: '',
                count: '',
                imageLink: '',
            }
        }
    }

    componentDidMount() {
        const { id } = this.props.match.params;

        axios.get("api/product/getById/" + id).then(product => {
            const response = product.data;

            this.setState({
                id: id,
                name: response.name,
                sku: response.sku,
                price: response.price,
                count: response.count,
                imageLink: response.imageLink
            })
        })
    }

    onUpdateCancel() {
        const { history } = this.props;
        history.push('/products');
    }

    onSubmit(e) {
        e.preventDefault();

        if (!validation(this.state))
            return;

        const { history } = this.props;

        let productObject = {
            id: this.state.id,
            name: this.state.name,
            sku: this.state.sku,
            price: this.state.price,
            count: this.state.count,
            imageLink: this.state.imageLink
        }

        axios.put("api/product/update", productObject).then(res => {
            history.push('/products');
        })

    }

    formObject = event => {

        event.preventDefault();

        const { name, value } = event.target;
        let error = { ...this.state.error };

        switch (name) {
            case "name":
                error.name = value.length < 3 ? "Name should be at least 3 characaters long" : "";
                break;
            case "sku":
                error.sku = value.length > 8 ? "SKU should not be longer than 8 characters" : "";
                break;
            case "price":
                error.price = priceExpression.test(value)
                    ? ""
                    : "Price is not valid"
                break;
            case "imageLink":
                error.imageLink = value.length < 1 ? "Image Link should be provided" : "";
                break;
            default:
                break;
        }

        this.setState({
            error,
            [name]: value
        })
    }

    render() {
        const { error } = this.state;

        return (
            <div className="product-form">
                <h3>Update product</h3>
                <form onSubmit={this.onSubmit}>
                    <div className="form-group">
                        <label>Product name: </label>
                        <input type="text"
                            required
                            className={error.name.length > 0 ? "is-invalid form-control" : "form-control"}
                            value={this.state.name}
                            name="name"
                            onChange={this.formObject}
                        />
                        {error.name.length > 0 && (
                            <span className="invalid-feedback">{error.name}</span>
                        )}
                    </div>
                    <div className="form-group">
                        <label>Product SKU: </label>
                        <input type="text"
                            required
                            className={error.sku.length > 0 ? "is-invalid form-control" : "form-control"}
                            value={this.state.sku}
                            name="sku"
                            onChange={this.formObject}
                        />
                        {error.sku.length > 0 && (
                            <span className="invalid-feedback">{error.sku}</span>
                        )}
                    </div>
                    <div className="row">
                        <div className="col col-md-6 col-sm-6 col-xs-12">
                            <div className="form-group">
                                <label>Product count: </label>
                                <input type="number"
                                    required
                                    className={error.count.length > 0 ? "is-invalid form-control" : "form-control"}
                                    value={this.state.count}
                                    name="count"
                                    onChange={this.formObject}
                                    min="0"
                                />
                                {error.count.length > 0 && (
                                    <span className="invalid-feedback">{error.count}</span>
                                )}
                            </div>
                        </div>
                        <div className="col col-md-6 col-sm-6 col-xs-12">
                            <div className="form-group">
                                <label>Price: </label>
                                <div className="input-group">
                                    <div className="input-group-prepend">
                                        <span className="input-group-text">$</span>
                                    </div>
                                    <input type="text"
                                        required
                                        className={error.price.length > 0 ? "is-invalid form-control" : "form-control"}
                                        aria-label="Amount (to the nearest dollar)"
                                        value={this.state.price}
                                        name="price"
                                        onChange={this.formObject}
                                    />
                                    {error.price.length > 0 && (
                                        <span className="invalid-feedback">{error.price}</span>
                                    )}
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="form-group">
                        <label>Product image link: </label>
                        <input type="text"
                            required
                            className={error.imageLink.length > 0 ? "is-invalid form-control" : "form-control"}
                            value={this.state.imageLink}
                            name="imageLink"
                            onChange={this.formObject}
                        />
                        {error.imageLink.length > 0 && (
                            <span className="invalid-feedback">{error.imageLink}</span>
                        )}
                    </div>

                    <div className="form-group">
                        <button onClick={this.onUpdateCancel} className="btn btn-default">Cancel</button>
                        <button type="submit" className="btn btn-success">Update</button>
                    </div>
                </form>
            </div>
        )
    }
}