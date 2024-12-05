import { Component, Input } from '@angular/core';
import { ReactiveFormsModule, FormControl, FormGroup, Validators } from '@angular/forms';
import { SimpleChanges } from '@angular/core';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent {
  @Input ('user') user;
  @Input ('updateUser') updateUser;
  @Input ('deleteUser') deleteUser;
  @Input ('addUser') addUser;
  txtButton;

  
  form = new FormGroup ({
    // 'id': new FormControl(null, [Validators.required, Validators.minLength(6)]),
    'firstName': new FormControl(null, [Validators.required, Validators.pattern(/^[a-zA-Z]+(?: [a-zA-Z]+)*$/)]),
    'lastName': new FormControl(null, Validators.required),
    'userRole': new FormControl(null, Validators.required),
    'age': new FormControl(null, Validators.required),
    'userId': new FormControl(null, Validators.required),
    
  });

  constructor(private userService:UserService){

    }


  ngOnInit(): void {
    
  }

  
getData(){
  if(this.user != undefined &&  this.updateUser == true){
    console.log(this.user.firstName)
    this.form.patchValue({
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      userRole: this.user.userRole,
      age: this.user.age,
      userId: this.user.userId,
    });

    this.txtButton= 'Update User';
    
  }
  else if(this.user != undefined && this.deleteUser == true) {
    this.form.patchValue({
      firstName: this.user.firstName,
      lastName: this.user.lastName,
      userRole: this.user.userRole,
      age: this.user.age,
      userId: this.user.userId,
    });

    this.txtButton= 'Delete User';

  } else {
    this.txtButton= 'Add User';

  }
  
}

onSubmit(){

}

ngOnChanges(changes: SimpleChanges) {
        
this.getData();

  
}
// при включении какого флага происходит какое действие при нажатии на кнопочку
save(){
  if(this.updateUser==true){
    this.userService.updateUser(this.form.value);
  } else if (this.deleteUser==true ) {
    this.userService.deleteUser(this.form.value);
  } else if (this.addUser==true ){
    this.userService.addUser(this.form.value);
  } 
  
}
}
 
