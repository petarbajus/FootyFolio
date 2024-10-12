import { nav } from "framer-motion/client";
import Image from "next/image";
import Link from "next/link";

export default function Navbar() {
    return (
        <nav className="w-full px-5 md:px-10 py-5 flex justify-between">
            <div className="flex items-center justify-center gap-x-2">
                <p className="text-3xl md:text-4xl">⚽️</p>
                <h1 className="text-2xl md:text-3xl text-wrap font-bold">footyfolio</h1>
            </div>

            <Link href="/" className="font-semibold hover:font-bold active:scale-95 transition-all duration-200 ease-in-out">
                Sign In
            </Link>
        </nav>
    )
}