import PlayerMarketCard from "@/components/player-market-card";

export default function MarketPage() {
  return (
    <div className="grid grid-cols-1 md:grid-cols-2 gap-12 mt-5">
      <PlayerMarketCard name="Lionel Messi" footballClub="Inter Miami" imageUrl="/placeholder-img.jpeg" position="CF" />
      <PlayerMarketCard name="Cristiano Ronaldo" footballClub="Manchester United" imageUrl="/placeholder-img.jpeg" position="CF" />
      <PlayerMarketCard name="Kylian Mbappe" footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="CF" />
      <PlayerMarketCard name="Neymar Jr." footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="LW" />
      <PlayerMarketCard name="Mohamed Salah" footballClub="Liverpool" imageUrl="/placeholder-img.jpeg" position="RW" />
    </div>
  )
}