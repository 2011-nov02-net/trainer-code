import { Component } from '@angular/core';

// a component is a TS class and a HTML template that work together
// to manage one part of the page with all its tightly-coupled logic.

// (other logic, that other components might be able to reuse, belongs in
//  an injected service)

// just like in .NET, a class can't be compiled on its own, it needs a
// project.

// likewise in ng, a component needs one module to declare it, to
// give it a context for existing.

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

}
