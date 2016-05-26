import {Component} from 'angular2/core'
import {RouteConfig, ROUTER_DIRECTIVES} from 'angular2/router';
import {HTTP_PROVIDERS } from 'angular2/http';

@Component({
    selector: 'app-name',
    templateUrl: 'app/layouts/_app.html',
    directives: [ROUTER_DIRECTIVES]
})
@RouteConfig([
    //{ path: '/', name: 'Home', component: HomeComponent, useAsDefault: true },
])
export class AppComponent { }