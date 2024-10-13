"use client";
import { UserButton } from "@clerk/nextjs";
import { usePathname } from "next/navigation";
import { navElements } from "@/lib/nav-elements";

export default function PageHeader() {

    const pathname = usePathname();
    const title = navElements.find((element) => element.href === pathname)?.title;
    const subtitle = navElements.find((element) => element.href === pathname)?.subtitle;

    return (
        <div className="flex items-center justify-between">
            <div>
                <h1 className="text-3xl font-bold">{title}</h1>
                <p className="text-muted-foreground">{subtitle}</p>
            </div>

            <UserButton />
        </div>
    )
}