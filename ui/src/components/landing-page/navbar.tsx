import Link from "next/link";
import Logo from "../logo";

export default function LandingPageNavbar() {
    return (
        <nav className="w-full px-5 md:px-10 py-5 flex justify-between">
            <Logo />

            <Link href="/register" className="font-semibold hover:font-bold active:scale-95 transition-all duration-200 ease-in-out">
                Sign In
            </Link>
        </nav>
    )
}