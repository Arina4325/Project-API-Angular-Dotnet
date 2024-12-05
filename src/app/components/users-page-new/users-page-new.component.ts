import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { UserService } from 'src/app/services/user.service';
import { FormControl, FormGroup} from '@angular/forms';
import { DataService } from 'src/app/services/data.service';
import { MatTableDataSource} from '@angular/material/table';


@Component({
  selector: 'app-users-page-new',
  templateUrl: './users-page-new.component.html',
  styleUrls: ['./users-page-new.component.scss']
  
})
export class UsersPageNewComponent implements OnInit{

user;


updateUser:boolean;
deleteUser:boolean;
addUser:boolean;

show: boolean = false;

userListNew: any [];
  
 userSearch = '';
 userListFiltered: any;
 usersChk:any=null;
 myForm = new FormGroup ({
   txt: new FormControl (""),
 });

  // возвращает данные в форму
 get txt(){
   return this.myForm.get('txt');
 }
//возвращает данные из сервиса
 get userList(){
  return this.userService.userList;
}

  constructor(private authService: AuthService, private userService:UserService, private dataService: DataService){
    this.userService.userList = this.userService.userList;
    this.getData();

    }


// берет данные для обработки из сервиса (АПИ или Джейсон)
  getData(){

    // старый вариант -  берет данные из джейсона для отображения в таблице через сервис dataserviсe

    // this.dataService.apiJsonLocalGet('/assets/json/users.json').subscribe(data => {
    // let users:any=data;
    // this.userService.userList=users.users;
    // this.userListNew=users.users;
    // });


    // измененный вариант - берет данные через сервис API запрос:
    this.dataService.apiGetUser().subscribe(data => {
      let users:any = data;
      this.userService.userList=users;
      this.userListNew=users;
     // console.log (data);
      });
  }

    ngOnInit(): void {

     // постоянно обновляет данные в таблице благодаря серчу ???
      this.myForm.get('txt')!.valueChanges.subscribe((data)=>{
      this.search();
      });

      this.userService.closePopup$.subscribe(data=>{
        if (data>0){
          this.show=false;
        }
      });
      // this.userService.userListChanged.subscribe(
      //   (users)=>{
      //     this.users = users;
      //   }
      // );
    }
    

  // 1 -  поиск  отключила - заменила алертом

  search(){

    this.userListNew = JSON.parse(JSON.stringify(this.userService.userList));
    this.userListNew = this.userService.userList;
     
    if(this.txt!.value != null && !Number(this.txt!.value) )
    this.userListNew =this.userListNew.filter(x => x.userId.indexOf(this.txt!.value)>-1 || x.firstName.indexOf(this.txt!.value )>-1 || x.lastName.indexOf(this.txt!.value )>-1)
   
   
    if(this.txt!.value && Number(this.txt!.value) )
      this.userListNew =this.userListNew.filter(x => x.age == this.txt!.value || x.ID.indexOf(this.txt!.value)>-1)

    // //alert ("Search!!");
    // this.userListNew = this.userService.userList;
     
    // if(this.txt!.value != null && !Number(this.txt!.value) )
    // this.userListNew =this.userList.filter(x => x.ID.indexOf(this.txt!.value)>-1 || x.firstname.indexOf(this.txt!.value )>-1 || x.lastName.indexOf(this.txt!.value )>-1)
   
   
    // if(this.txt!.value && Number(this.txt!.value) )
    //   this.userListNew =this.userList.filter(x => x.age == this.txt!.value || x.ID.indexOf(this.txt!.value)>-1)
  }



  // 2- edit отключила - заменила алертом
  onEdit(item:any){

   // alert ("Edit!!");
    if(item){
      this.show = true;
      this.user = item;
      this.deleteUser = false;
      this.updateUser = true;
      this.addUser = false;
    }
    else {
      this.show = true;
      this.user = null;
      this.updateUser = false;
      this.addUser = true;
      this.deleteUser = true;
      
    }
    
  }


  // 3- делит отключила - заменила алертом


  onDelete(item:any){

  //  alert ("delete!!");


    if(item){
      this.show = true;
      this.user = item;
      this.deleteUser = true;
      this.updateUser = false;
      this.addUser = false;
    }
    else {
      this.show = true;
      this.user = null;
      this.deleteUser = false;
      this.addUser = true;
      this.updateUser = true;
    }
    
  }


  // 4- эдд отключила - заменила алертом - вернула
  onAdd(item: any){

   // alert ("add!!");

    if(item){
      this.show = true;
      this.user = null;
      this.deleteUser = false;
      this.updateUser = false;
      this.addUser = true;
    }
    else {
      this.show = true;
      this.user = item;
      this.updateUser = true;
      this.deleteUser = true;
      this.addUser = false;
      
    }
  }

}
