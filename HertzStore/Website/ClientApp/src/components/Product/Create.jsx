import React, { Component } from "react";
import axios from "axios";
import { validation, priceExpression } from '../../helpers/';

export class Create extends Component {
    constructor(props) {
        super(props);

        this.onSubmit = this.onSubmit.bind(this);

        this.state = {
            name: '',
            sku: '',
            price: 0,
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

    onSubmit(e) {
        e.preventDefault();
        if (!validation(this.state))
            return;

        const { history } = this.props;

        let productObject = {
            name: this.state.name,
            sku: this.state.sku,
            price: this.state.price,
            count: this.state.count,
            imageLink: this.state.imageLink
        }

        axios.post("api/product/create", productObject).then(res => {
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
                <h3>Add new product</h3>
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
                        <input type="submit" value="Add Product" className="btn btn-primary" />
                    </div>
                </form>
            </div>
        )
    }
}