import { LucideIcon, Home, PackageOpen, Settings } from "lucide-react";
// import { LucideIcon, Home, PackageOpen, Settings, ¿¿¿¿ } from "lucide-react";

export const navElements: {
    title: string;
    icon: LucideIcon;
    href: string;
    subtitle: string;
}[] = [
        {
            title: "Home",
            icon: Home,
            href: "/home",
            subtitle: "Welcome to the hub",
        },
        {
            title: "Market",
            icon: PackageOpen,
            href: "/market",
            subtitle: "Browse the marketplace",
        },
        {
            title: "Settings",
            icon: Settings,
            href: "/settings",
            subtitle: "Manage your account",
        },
        // {
        //     title: "Help",
        //     icon: HelpCircle,
        //     href: "/help",
        //     subtitle: "Get help",
        // },
    ];
