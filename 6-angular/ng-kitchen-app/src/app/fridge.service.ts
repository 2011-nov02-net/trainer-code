import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FridgeItem } from './fridge-item';

// services needs the Injectable decorator

//

@Injectable({
  // register the service as a singleton across the whole app
  providedIn: 'root',
  // other options... Component providers, NgModule providers
  // (i.e. one instance per component instance,
  //   one instance within a module as a whole)
})
export class FridgeService {
  private baseUrl = 'https://localhost:44336/api/appliances/fridge';

  // angular uses constructors to request services for DI just like ASP.NET
  constructor(private http: HttpClient) {}
  // in TS, if you put an access modifier on a ctor parameter,
  // it's a quick shorthand for declaring that property on the class,
  // and assigning the param to that property.

  // HttpClient uses rxjs Observables to manage the asynchronicity
  // of http, instead of Promises. Observables are more complicated
  // but more powerful
  getFridgeItems(): Promise<FridgeItem[]> {
    return this.http.get<FridgeItem[]>(`${this.baseUrl}/contents`)
      .toPromise();
  }
}
