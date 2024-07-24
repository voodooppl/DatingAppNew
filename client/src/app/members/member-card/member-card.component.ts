import { Component, input } from '@angular/core';
import { Member } from '../../_models/member';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-member-card',
  standalone: true,
  imports: [RouterLink, RouterLinkActive],
  templateUrl: './member-card.component.html',
  styleUrl: './member-card.component.css'
})
export class MemberCardComponent {
  member = input.required<Member>();

}
