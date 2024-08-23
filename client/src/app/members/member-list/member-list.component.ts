import { Component, OnInit, inject } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { MemberCardComponent } from "../member-card/member-card.component";
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { FormsModule } from '@angular/forms';
import { ButtonsModule } from 'ngx-bootstrap/buttons';

@Component({
  selector: 'app-member-list',
  standalone: true,
  templateUrl: './member-list.component.html',
  styleUrl: './member-list.component.css',
  imports: [MemberCardComponent, PaginationModule, FormsModule, ButtonsModule]
})
export class MemberListComponent implements OnInit {
  membersService = inject(MembersService);
  genderList = [{value: 'male', display: 'Males'}, {value: 'female', display: 'Females'}];

  ngOnInit(): void {
    if (!this.membersService.paginatedResult()) this.getMembers();
  }

  resetFilters(){
    this.membersService.resetUserParams();
    this.getMembers();
  }

  getMembers() {
    this.membersService.getMembers();
  }

  pageChanged(event: any) {
    if (this.membersService.userParams().pageNumber !== event.page) {
      this.membersService.userParams().pageNumber = event.page;
      this.getMembers();
    }
  }
}
