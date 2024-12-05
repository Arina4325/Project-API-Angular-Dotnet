import { Component } from '@angular/core';

@Component({
  selector: 'app-calculator',
  templateUrl: './calculator.component.html',
  styleUrls: ['./calculator.component.scss']
})
export class CalculatorComponent {

  public first: number = 1;
  public second: number = 1;

  public operation: string = "+";

  public operations: string[]=['+', '-', '*', '/'];

  public result: number | undefined = undefined;

  public calc(){
    switch(this.operation){
      case "+":
        this.result = this.first + this.second;
        break;
      case "-":
        this.result = this.first - this.second;
        break;
      case "*":
        this.result = this.first * this.second;
        break;
      case "/":
        this.result = this.first / this.second;
        break;
        

    }

  }

}
