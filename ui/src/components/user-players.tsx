import { MyPlayersFootballerCard } from "./footballer-home-card";
import UserHomeCard from "./user-home-card";

export default function UserPlayerCard() {
  return (
    <UserHomeCard title="My Players">
      <MyPlayersFootballerCard name="Lionel Messi" footballClub="Inter Miami" imageUrl="/placeholder-img.jpeg" position="CF" />
      <MyPlayersFootballerCard name="Cristiano Ronaldo" footballClub="Manchester United" imageUrl="/placeholder-img.jpeg" position="CF" />
      <MyPlayersFootballerCard name="Kylian Mbappe" footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="CF" />
      <MyPlayersFootballerCard name="Neymar Jr." footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="LW" />
      <MyPlayersFootballerCard name="Mohamed Salah" footballClub="Liverpool" imageUrl="/placeholder-img.jpeg" position="RW" />
    </UserHomeCard>
  )
}