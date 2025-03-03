import { Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { AdminComponent } from './components/admin/admin.component';
import { SalesComponent } from './components/sales/sales.component';
import { PurchaseComponent } from './components/purchase/purchase.component';
import { authGuard } from './auth.guard';
import { AdduserComponent } from './components/adduser/adduser.component';
import { AllusersComponent } from './components/allusers/allusers.component';
import { UpdateComponent } from './components/updateuser/update.component';
import { AddproductComponent } from './components/addproduct/addproduct.component';
import { AllproductsComponent } from './components/allproducts/allproducts.component';
import { UpdateproductComponent } from './components/updateproduct/updateproduct.component';
import { AddcustomerComponent } from './components/addcustomer/addcustomer.component';
import { AllcustomersComponent } from './components/allcustomers/allcustomers.component';
import { UpdatecustomerComponent } from './components/updatecustomer/updatecustomer.component';
import { AddsupplierComponent } from './components/addsupplier/addsupplier.component';
import { AllsuppliersComponent } from './components/allsuppliers/allsuppliers.component';
import { UpdatesupplierComponent } from './components/updatesupplier/updatesupplier.component';
import { AllsalesorderComponent } from './components/allsalesorder/allsalesorder.component';
import { AllpurchaseorderComponent } from './components/allpurchaseorder/allpurchaseorder.component';
import { AddsalesorderComponent } from './components/addsalesorder/addsalesorder.component';
import { AddpurchaseorderComponent } from './components/addpurchaseorder/addpurchaseorder.component';



export const routes: Routes = [
    { path: '', component: LoginComponent, pathMatch: 'full' },
    {
        path: 'admin',
        component: AdminComponent,
        pathMatch: 'full',
        canActivate: [authGuard],
        data: { allowedRoles: ['admin'] }
    },
    {
        path: 'sales',
        component: SalesComponent,
        pathMatch: 'full',
        canActivate: [authGuard],
        data: { allowedRoles: ['sales'] }
    },
    {
        path: 'purchase',
        component: PurchaseComponent,
        pathMatch: 'full',
        canActivate: [authGuard],
        data: { allowedRoles: ['purchase'] }
    },
    {
        path: 'admin/adduser',
        component: AdduserComponent,
        pathMatch: 'full',
        canActivate: [authGuard],
        data: { allowedRoles: ['admin'] }
    },
    {
        path: 'admin/allusers',
        component: AllusersComponent,
        pathMatch: 'full',
        canActivate: [authGuard],
        data: { allowedRoles: ['admin'] }
    },
    {
        path: 'admin/allusers/update/:id',
        component: UpdateComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin'] }
    },
    {
        path: 'admin/allproducts/update/:id',
        component: UpdateproductComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase', 'sales'] }
    },
    {
        path: 'admin/allcustomers/update/:id',
        component: UpdatecustomerComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'sales'] }
    },
    {
        path: 'admin/allsuppliers/update/:id',
        component: UpdatesupplierComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    }
    ,
    {
        path: 'admin/addproduct',
        component: AddproductComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    },
    {
        path: 'admin/allproducts',
        component: AllproductsComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin'] }
    },
    {
        path: 'admin/addcustomer',
        component: AddcustomerComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'sales'] }
    },
    {
        path: 'admin/allcustomers',
        component: AllcustomersComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'sales'] }
    },
    {
        path: 'admin/addsupplier',
        component: AddsupplierComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    },
    {
        path: 'admin/allsuppliers',
        component: AllsuppliersComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    },
    {
        path: 'admin/allsalesorder',
        component: AllsalesorderComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'sales'] }
    },
    {
        path: 'admin/allpurchaseorder',
        component: AllpurchaseorderComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    },
    {
        path: 'sales/addsalesorder',
        component: AddsalesorderComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'sales'] },

    },
    {
        path: 'purchase/addpurchaseorder',
        component: AddpurchaseorderComponent,
        canActivate: [authGuard],
        data: { allowedRoles: ['admin', 'purchase'] }
    },

    { path: '**', redirectTo: '' }
];
