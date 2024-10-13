import UserPlayers from "@/components/user-players";
import UserWishlist from "@/components/user-wishlist";
import { SignOutButton } from "@clerk/nextjs";

export default function HomePage() {
    return (
        <div className="flex gap-4">
            <UserPlayers />
            <UserWishlist />
        </div>
    )
}