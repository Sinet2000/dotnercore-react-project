import React, { Component } from "react";
import axios from "axios";
import { connect } from "react-redux";
import { getAllProducts } from '../../actions/productActions';

export class Products extends Component {
    constructor(props) {
        super(props);

        this.onProductUpdate = this.onProductUpdate.bind(this);
        this.onProductDelete = this.onProductDelete.bind(this);
        this.getDateWarning = this.getDateWarning.bind(this);
        this.addProductIdToDelete = this.addProductIdToDelete.bind(this);
        this.deleteSelectedProducts = this.deleteSelectedProducts.bind(this);
        this.createNewProduct = this.createNewProduct.bind(this);

        this.state = {
            products: [],
            selectdProductsToDelete: [],
            loading: true,
            failed: false,
            error: ''
        }
    }

    componentDidMount() {
        this.props.getAllProducts();
    }

    componentDidUpdate(prevProps) {
        if (prevProps.products.data != this.props.products.data) {
            this.setState({ products: this.props.products.data });
        }
    }

    onProductUpdate(id) {
        const { history } = this.props;
        history.push('/update/' + id);
    }

    onProductDelete(id) {
        const { history } = this.props;
        history.push('/delete/' + id);
    }

    createNewProduct() {
        const { history } = this.props;
        history.push('/create');
    }

    deleteSelectedProducts() {
        const { history } = this.props;

        axios.post("api/product/deleteSelectedProducts", this.state.selectdProductsToDelete).then(res => {
            window.location.reload();
            //let products = this.state.products;
            //this.state.selectdProductsToDelete.forEach(id => {
            //    products.splice(id, 1);
            //    this.setState({ products })
            //});
        })
    }

    getDateWarning(date) {
        var createDate = new Date(date);
        var currentDate = new Date();
        var timeDiff = currentDate.getTime() - createDate.getTime();

        if ((timeDiff / (1000 * 60 * 60 * 24) >= 30))
            return "date-warning";
    }

    addProductIdToDelete(id) {
        var selectedIds = this.state.selectdProductsToDelete;

        if (!selectedIds.includes(id)) {
            selectedIds.push(id);
        } else {
            selectedIds.splice(selectedIds.indexOf(id), 1);
        }

        this.setState({ selectdProductsToDelete: selectedIds });
    }

    renderAllProductsTable(products) {
        return (
            <table className="table table-stripped products-table">
                <thead>
                    <tr>
                        <th>Delete?</th>
                        <th>Name</th>
                        <th>SKU</th>
                        <th>Count</th>
                        <th>Price</th>
                        <th>Create Date</th>
                        <th>Image</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        products.map(product => (
                            <tr key={product.id}>
                                <td>
                                    <div className="form-check">
                                        <input type="checkbox"
                                            className="form-check-input"
                                            onClick={() => this.addProductIdToDelete(product.id)}
                                        />
                                    </div>
                                </td>
                                <td>{product.name}</td>
                                <td>{product.sku}</td>
                                <td>{product.count}</td>
                                <td>{product.price}</td>
                                <td className={this.getDateWarning(product.createDate)}>{new Date(product.createDate).toISOString().slice(0, 10)}</td>
                                <td>
                                    <img src={product.imageLink} />
                                </td>
                                <td>
                                    <div className="form-group">
                                        <button onClick={() => this.onProductUpdate(product.id)} className="btn btn-success mr-3" >
                                            Update
                                        </button>
                                        <button onClick={() => this.onProductDelete(product.id)} className="btn btn-danger" >
                                            Delete
                                        </button>
                                    </div>
                                </td>
                            </tr>
                        ))
                    }
                </tbody>
            </table>
        )
    }

    render() {
        let content = this.props.products.loading ?
            (
                <p>
                    <em>Loading ...</em>
                </p>
            ) : (
                this.state.products.length && this.renderAllProductsTable(this.state.products)
            );

        return (
            <div>
                <div className="row">
                    <div className="col-9">
                        <h1>All products</h1>
                    </div>
                    <div className="col-3">
                        <button onClick={() => this.createNewProduct()} className="btn btn-success" >
                            Create new product
                        </button>
                    </div>
                </div>
                <p>Here you can see all products</p>
                {content}
                {
                    this.state.products.length > 0
                    && <div>
                            <button onClick={() => this.deleteSelectedProducts()} className="btn btn-danger" >
                                Delete selected
                            </button>
                        </div>
                }
            </div>
        );
    }
}

const mapStateToProps = ({ products }) => ({
    products
});

export default connect(mapStateToProps, { getAllProducts })(Products);