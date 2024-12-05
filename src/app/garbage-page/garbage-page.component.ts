import { Component } from '@angular/core';

@Component({
  selector: 'app-garbage-page',
  templateUrl: './garbage-page.component.html',
  styleUrls: ['./garbage-page.component.scss']
})
export class GarbagePageComponent {

public text = "text with two-way binding method"
public tooltip1 = "Tooltip about smthng - one way binding"
public tooltip2 = "Tooltip about smthng - two way binding"

showMessage() {
  alert("BOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO");
}

}
