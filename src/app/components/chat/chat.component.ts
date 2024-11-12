// src/app/components/chat/chat.component.ts
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';  // <-- Import FormsModule here
import { SignalRService } from '../../services/signal-r.service';
import { WebSocketService } from '../../services/web-socket.service';

@Component({
  selector: 'app-chat',
  standalone: true,  // Standalone component
  imports: [FormsModule],  // <-- Import FormsModule here
  templateUrl: './chat.component.html',
  styleUrls: ['./chat.component.css']
})
export class ChatComponent {
  message: string = '';
  messages: string[] = [];

  constructor(private webSocketService: WebSocketService) {}

  ngOnInit(): void {
    this.webSocketService.connect('ws://0.0.0.0:8181');
    this.webSocketService.getMessages().subscribe((msg) => {
      this.messages.push(msg);
    });
  }

  sendMessage(): void {
    this.webSocketService.sendMessage(this.message);
    this.message = ''; // Clear input field after sending
  }
}
