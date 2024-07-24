import { Component, OnInit, inject } from '@angular/core';
import { MembersService } from '../../_services/members.service';
import { Member } from '../../_models/member';
import { MemberCardComponent } from "../member-card/member-card.component";

@Component({
    selector: 'app-member-list',
    standalone: true,
    templateUrl: './member-list.component.html',
    styleUrl: './member-list.component.css',
    imports: [MemberCardComponent]
})
export class MemberListComponent implements OnInit {
  private membersService = inject(MembersService)
  members: Member[] = [];
  
  ngOnInit(): void {
    this.getMembers();
  }

  getMembers(){
    this.membersService.getMembers().subscribe({
      next: response => this.members = response,
    })
  }
}
