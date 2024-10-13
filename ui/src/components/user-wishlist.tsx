import UserHomeCard from "./user-home-card";
import { WishlistFootballerCard } from "./footballer-home-card";

export default function UserWishlist() {
    return (
        <UserHomeCard title="My Wishlist">
            <WishlistFootballerCard name="Lionel Messi" footballClub="Inter Miami" imageUrl="/placeholder-img.jpeg" position="CF" />
            <WishlistFootballerCard name="Cristiano Ronaldo" footballClub="Manchester United" imageUrl="/placeholder-img.jpeg" position="CF" />
            <WishlistFootballerCard name="Kylian Mbappe" footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="CF" />
            <WishlistFootballerCard name="Neymar Jr." footballClub="Paris Saint-Germain" imageUrl="/placeholder-img.jpeg" position="LW" />
            <WishlistFootballerCard name="Mohamed Salah" footballClub="Liverpool" imageUrl="/placeholder-img.jpeg" position="RW" />
        </UserHomeCard>
    )
}