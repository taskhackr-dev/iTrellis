import React, { Component } from 'react';
import {
    Button, FormGroup, ControlLabel,
    FormControl, HelpBlock
} from 'react-bootstrap';

export class MapNavigation extends Component {
    displayName = MapNavigation.name;

    constructor(props) {
        super(props);
        this.state = {
            shortestRoute: '',
            directions: '',
            directionsValidationState: null,
            hasError: false
        };
        this.handleChange = this.handleChange.bind(this);
        this.handleClick = this.handleClick.bind(this);
    }

    static handleErrors(response) {
        if (!response.ok) {
            throw Error(response.statusText);
        }
        return response;
    }

    static validateDirections(directions) {
        //TODO: Implement validation as Regex test.
        let isValid = true;

        directions.split(',').forEach(el => {
            el = el.trim();

            if (el.length < 2) {
                isValid = false;
                return;
            }
            if (el[0].toLowerCase() != 'l' && el[0].toLowerCase() != 'r') {
                isValid = false;
                return;
            }

            if (isNaN(parseInt(el.substr(1)))) {
                isValid = false;
                return;
            }
        });

        return isValid;
    }

    componentDidCatch(error, info) {
        // Display fallback UI
        this.setState({ hasError: true });
    }

    handleChange(event) {
        this.setState({
            directions: event.target.value,
            shortestRoute: '',
            directionsValidationState: null
        });
    }

    handleClick() {
        if (!MapNavigation.validateDirections(this.state.directions)) {
            this.setState({ directionsValidationState: 'error' });
            return;
        }

        fetch('api/Route/GetShortestRoute', {
            method: 'POST',
            body: JSON.stringify(this.state.directions),
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(MapNavigation.handleErrors)
            .then(response => response.json())
            .then(data => this.setState({ shortestRoute: data }))
            .catch(error => this.setState({ hasError: true }));
    }

    render() {
        if (this.state.hasError) {
            return (<h1>Something went wrong.</h1>);
        }

        return (
            <div>
                <h1>Shortest Route Finder</h1>

                <p>
                    The shortest route finder takes a comma delimited list of
                    left/right directions and determines the shortest number of
                    blocks to your destination.  The directions should be in the
                    form of "L3, R2, R4" where the first character is the direction
                    and the number is the number of blocks to travel.
                </p>

                <form>
                    <FormGroup controlId="formControlsTextarea" validationState={this.state.directionsValidationState}>
                          <ControlLabel>Directions</ControlLabel>
                        <FormControl componentClass="textarea" placeholder="textarea" onChange={this.handleChange} />
                        <HelpBlock>Directions should be comma delimited list of directions.</HelpBlock>
                    </FormGroup>

                    <Button onClick={this.handleClick}>Get Shortest Route</Button>
                </form>

                <h3>Shortest Route: <strong>{this.state.shortestRoute}</strong></h3>

            </div>
        );
    }
}