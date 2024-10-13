"use client";

import { Button } from "@/components/ui/button";
import {
    Sheet,
    SheetContent,
    SheetTrigger,
} from "@/components/ui/sheet";
import { Menu, DoorOpen } from 'lucide-react';
import Link from 'next/link';
import { usePathname } from 'next/navigation';
import Logo from './logo';
import { cn } from '@/lib/utils';
import { navElements } from '@/lib/nav-elements';
import { useState } from 'react';
import { SignOutButton } from "@clerk/nextjs";

interface SidebarProps {
    mobile?: boolean;
    onClose?: () => void; // New onClose prop to handle closing on mobile
}

export function Sidebar({ mobile = false, onClose }: SidebarProps) {
    const pathname = usePathname();

    const NavItems = () => (
        <div className="space-y-4 py-4">
            <div className="px-3 py-2">
                <h2 className="mb-2 px-4 text-lg font-semibold tracking-tight">
                    <Logo />
                </h2>
                <div className="space-y-3">
                    {navElements.map((item, index) => (
                        <Link
                            key={index}
                            href={item.href}
                            className={cn(
                                "flex items-center w-full p-2 rounded-md hover:bg-slate-100",
                                pathname.includes(item.href.slice(1)) && "bg-slate-100"
                            )}
                            onClick={onClose} // Close the sidebar when a link is clicked
                        >
                            <item.icon className="mr-2 h-4 w-4" />
                            {item.title}
                        </Link>
                    ))}

                    <SignOutButton>
                        <Button className="w-full">
                            <DoorOpen className="mr-2 h-4 w-4" />
                            Logout
                        </Button>
                    </SignOutButton>
                </div>
            </div>
        </div>
    );

    return (
        <div className={cn(
            "h-full md:w-72 md:flex-col border-r bg-white min-h-screen",
            mobile ? "w-64" : "hidden md:flex" // Conditionally adjust width for mobile
        )}>
            <div className="flex flex-col flex-grow pt-5 overflow-y-auto">
                <NavItems />
            </div>
        </div>
    );
}

export function MobileSidebar() {
    const [open, setOpen] = useState(false);

    return (
        <Sheet open={open} onOpenChange={setOpen}>
            <SheetTrigger asChild>
                <Button variant="outline" size="icon" className="md:hidden">
                    <Menu className="h-6 w-6" />
                    <span className="sr-only">Toggle navigation menu</span>
                </Button>
            </SheetTrigger>
            <SheetContent side="left" className="p-0 w-64"> {/* Set the width to 64 (or another value) */}
                {/* Pass the onClose callback to close the sheet on mobile when a link is clicked */}
                <Sidebar mobile={true} onClose={() => setOpen(false)} />
            </SheetContent>
        </Sheet>
    );
}