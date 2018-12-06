import React, {Component, ReactNode} from "react";
import Navigation from "../../components/navigation/navigation";

export default class Home extends Component {

    public render(): ReactNode {
        return (
            <>
                <Navigation/>
                <div className="container body-content">
                    <div className="jumbotron">
                        <h1>ASP.NET</h1>
                        <p className="lead">ASP.NET is a free web framework for building great Web sites and Web
                            applications
                            using HTML, CSS and JavaScript.</p>
                        <p>
                            <a href="https://asp.net" className="btn btn-primary btn-lg">Learn more &raquo;</a>
                        </p>
                    </div>

                    <div className="row">
                        <div className="col-md-4">
                            <h2>Getting started</h2>
                            <p>
                                ASP.NET MVC gives you a powerful, patterns-based way to build dynamic websites that
                                enables a clean separation of concerns and gives you full control over markup
                                for enjoyable, agile development.
                            </p>
                            <p>
                                <a className="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301865">Learn
                                    more &raquo;</a>
                            </p>
                        </div>
                        <div className="col-md-4">
                            <h2>Get more libraries</h2>
                            <p>NuGet is a free Visual Studio extension that makes it easy to add, remove, and update
                                libraries
                                and tools in Visual Studio projects.</p>
                            <p>
                                <a className="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301866">Learn
                                    more &raquo;</a>
                            </p>
                        </div>
                        <div className="col-md-4">
                            <h2>Web Hosting</h2>
                            <p>You can easily find a web hosting company that offers the right mix of features and price
                                for
                                your applications.</p>
                            <p>
                                <a className="btn btn-default" href="https://go.microsoft.com/fwlink/?LinkId=301867">Learn
                                    more &raquo;</a>
                            </p>
                        </div>
                    </div>
                    <hr/>
                    <footer>
                        <p>&copy; @DateTime.Now.2018 - My ASP.NET Application</p>
                    </footer>
                </div>
            </>
        );
    }

}