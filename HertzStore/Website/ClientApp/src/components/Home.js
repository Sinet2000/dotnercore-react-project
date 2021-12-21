import React, { Component } from 'react';

export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <h1>Welcome to Hertz Shop</h1>
                <p>Use this manager to manage your products, by:</p>
                <ul>
                    <li>Add a new product</li>
                    <li>Update a product</li>
                    <li>Delete a product</li>
                    <li>Show all products</li>
                </ul>
            </div>
        );
    }
}
