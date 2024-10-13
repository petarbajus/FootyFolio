import UserPlayerCard from "@/components/user-players";
import UserWishlist from "@/components/user-wishlist";

export default function HomePage() {
    return (
        <div className="flex flex-col md:flex-row grow gap-4">
            <UserPlayerCard />
            <UserWishlist />
        </div>
    )
}