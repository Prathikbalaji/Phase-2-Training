import { Routes } from '@angular/router';
import { OrganisationListComponent } from './organisation-list/organisation-list.component';
import { OrgDetailsComponent } from './org-details/org-details.component';
import { AddOrgComponent } from './add-org/add-org.component';
import { DelOrgComponent } from './del-org/del-org.component';
import { UpdateorgComponent } from './updateorg/updateorg.component';

export const routes: Routes = [
    {path : '',component:OrganisationListComponent},
    {path : 'Org/:id',component:OrgDetailsComponent},
    {path : 'add',component:AddOrgComponent},
    {path : 'Del/:id',component:DelOrgComponent},
    {path : 'Upd/:id',component:UpdateorgComponent}
];
