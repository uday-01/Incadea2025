import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import{NgIf, NgClass, NgFor, CommonModule} from '@angular/common'
import { CustomPipePipe } from '../custom-pipe.pipe';


@Component({
  selector: 'app-login',
  standalone:true,
  imports: [NgIf, NgClass, NgFor, FormsModule, CustomPipePipe,CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
  
  
  providers:[],
  

})
export class LoginComponent {
  user = {email:'',password:''};
  message: string =''

  onSubmit()
  {
    if(this.user.email == "admin@incadea.com" && this.user.password=="admin@123"){
      this.message = 'Login Sucessful';
      
      
    }else{
      this.message = 'Invalid Credentials ,please check it'
    }
  }

}
