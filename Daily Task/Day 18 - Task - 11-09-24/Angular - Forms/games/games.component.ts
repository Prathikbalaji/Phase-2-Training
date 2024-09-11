import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-games',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './games.component.html',
  styleUrl: './games.component.css'
})

export class GamesComponent {
  gamelst:Games[]=[
    {GameID : 1,GameName : 'Battle Grounds Mobile India',GameType:'Multi Player',GamePrice:'$500',InStock:5,Rating : 3,GameImage : '/public/bgmi.png'},
    {GameID : 2,GameName : 'Call of Duty',GameType:'Multi Player',GamePrice:'$700',InStock:0,Rating : 2,GameImage : '/public/cod.webp'},
    {GameID : 3,GameName : 'Plants vs Zombies',GameType:'Single Player',GamePrice:'$100',InStock:10,Rating : 5,GameImage : '/public/pvz.jpg'},
    {GameID : 4,GameName : 'Among Us',GameType:'Multi Player',GamePrice:'$50',InStock:7,Rating : 2,GameImage : '/public/among.webp'},
    {GameID : 5,GameName : 'Black Myth Wukong',GameType:'Single Player',GamePrice:'$1000',InStock:2,Rating : 3,GameImage : '/public/wuk.jpeg'},
    {GameID : 6,GameName : 'Machinarium',GameType:'Single Player',GamePrice:'$500',InStock:15,Rating : 4,GameImage : '/public/mch.png'}
  ]

  cart: Games[] = [];

  Total:number=0

  addToCart(game: Games) {
    this.cart.push(game);
    console.log('Cart: ', this.cart);  
    let totalCost = this.cart.reduce((acc, game) => acc + parseFloat(game.GamePrice.slice(1)), 0);
    this.Total = totalCost;
    game.InStock--;
  }

  buy(){
    if (this.cart.length == 0){
      alert('Your cart is empty!');
    }
    else{
      console.log('Bought Games: ', this.cart);  
      console.log('Total Price: $',this.Total);  
      this.cart = [];
    }
  }

}

class Games{
  GameID?:number
  GameName?:string
  GameType?:string
  GamePrice:string=""
  InStock:number = 0
  Rating:number = 0
  GameImage?:string
}
