import { Component } from '@angular/core';
import Card from './card';
import CardService from './card-service';

@Component({
  selector: 'app',
  template: `
    <button (click)="newDeck()">New Deck</button>
    <button (click)="drawCard()">Draw Card</button>
    <div>
      <img *ngFor="let card of cards" [src]="card.image" [alt]="card.code">
    </div>
  `
})
export class AppComponent {
  cardService: CardService;
  cards: Card[] = [];

  constructor() {
    this.cardService = new CardService();
  }

  newDeck() {
    // empty the card container of any existing cards
    this.cards = [];

    this.cardService.newDeck().catch((error: Error) => {
      // TODO: display error
    });
  }

  drawCard() {
    this.cardService.drawCard().then(
      card => {
        this.cards.push(card);
      },
      (error: Error) => {
        // TODO: display error
      }
    );
  }
}
