import React, { Component } from "react";
import axios from "axios";

export class Delete extends Component {
    constructor(props) {
        super(props);

        this.onCancel = this.onCancel.bind(this);
        this.onConfirmation = this.onConfirmation.bind(this);

        this.state = {
            name: '',
            sku: '',
            price: 0.00,
            count: 0,
            imageLink: ''
        }
    }

    componentDidMount() {
        const { id } = this.props.match.params;

        axios.get("api/product/getById/" + id).then(product => {
            const response = product.data;

            this.setState({
                name: response.name,
                sku: response.sku,
                price: response.price,
                count: response.count,
                imageLink: response.imageLink
                // date: new Date(response.date).toISOString().slice(0, 10)
            })
        });
    }

    onCancel(e) {
        const { history } = this.props;
        history.push('/products');
    }

    onConfirmation(e) {
        const { id } = this.props.match.params;
        const { history } = this.props;

        axios.delete("api/product/delete/" + id).then(res => {
            history.push('/products');
        })
    }

    render() {
        return (
            <div style={{ marginTop: 10 }}>
                <h2>Delete product confirmation</h2>
                <div className="card">
                    <div className="card-body">
                        <h4 className="card-title">{this.state.name}</h4>
                        <p className="card-text">{this.state.sku}</p>
                        <button onClick={this.onCancel} className="btn btn-default">
                            Cancel
                        </button>
                        <button onClick={this.onConfirmation} className="btn btn-danger">
                            Confirm
                        </button>
                    </div>
                </div>
            </div>
        )
    }
}