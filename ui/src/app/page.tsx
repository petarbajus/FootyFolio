import { LandingPageHero } from "@/components/landing-page/hero";
import LandingPageNav from "@/components/landing-page/navbar";
import { ModeToggle } from "@/components/theme-toggle";
import Image from "next/image";

export default function Home() {
  return (
    <div>
      <LandingPageNav />
      <LandingPageHero />
    </div>
  );
}
