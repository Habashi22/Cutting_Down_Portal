import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register';
import { LoginComponent } from './components/login/login';
import { CuttingDownIgnoredComponent } from './components/cuttingDownIgnoredComponent/cuttingdown-ignored/cuttingdown-ignored';
import { Addcuttingdownignored } from './components/cuttingDownIgnoredComponent/addcuttingdownignored/addcuttingdownignored';
import { CuttingDownMaster } from './components/cuttingDownMasterComponent/cutting-down-master/cutting-down-master';
import { AddCuttingDownComponent } from './components/cuttingDownMasterComponent/add-cutting-down-master/add-cutting-down-master';
import { GetByIdcuttingDownMaster } from './components/cuttingDownMasterComponent/getByIdCuttingDownMaster/get-by-idcutting-down-master/get-by-idcutting-down-master';
export const routes: Routes = [
  { path: 'register', component: RegisterComponent },
     { path: 'login', component: LoginComponent },
     { path: 'cuttingdownignored', component: CuttingDownIgnoredComponent },
     { path: 'addCuttingDownIgnored', component: Addcuttingdownignored },
     { path: 'cuttingDownmMaster', component: CuttingDownMaster },
     { path: 'addcuttingdownmaster', component: AddCuttingDownComponent },
     { path: 'getbyidcuttingdownmaster/:id', component: GetByIdcuttingDownMaster}










 
];
