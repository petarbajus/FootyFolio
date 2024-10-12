import { Button } from "../ui/button";
import { RainbowButton } from "../ui/rainbow-button";

export function LandingPageHero() {
    return (
        <div className="h-full flex flex-col items-center pt-20 gap-5 text-wrap">
            <h1 className="font-display text-center font-bold text-black dark:text-white text-2xl md:text-7xl">
                Support lower league football
            </h1>

            <RainbowButton className="bg-white text-white shadow-sm mt-8">Begin your journey ⚽️</RainbowButton>
        </div>
    )
}