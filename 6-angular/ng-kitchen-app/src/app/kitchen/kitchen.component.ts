import { Component, OnInit } from '@angular/core';
import { FridgeItem } from '../fridge-item';
import { FridgeService } from '../fridge.service';

// in ng, a component needs the Component decorator,
// with config inside.

@Component({
  // defines which elements on the page will be managed by this class's logic & template.
  selector: 'app-kitchen', // (css selector)
  // every component needs one template. it be internal with "template", or
  // external with "templateUrl"
  templateUrl: './kitchen.component.html',
  // a component can have multiple CSS strings / files.
  // when the CSS for a component is compiled, it's automatically made to only
  //   apply to that component, can't pollute the rest of the app
  styleUrls: ['./kitchen.component.css']

  // other properties that go here...
  // animations
  // providers - services that are scoped to this component lifetime-wise
})
export class KitchenComponent implements OnInit {

  fridgeContents: FridgeItem[] | null = null;

  constructor(private fridgeService: FridgeService) { }

  ngOnInit(): void {
    this.fridgeService.getFridgeItems()
      .then(items => {
        this.fridgeContents = items;
      });
    // arguably better would be to use observable here,
    // not even subscribing here, but in the component with AsyncPipe
    // but this is fine for now
  }
}
