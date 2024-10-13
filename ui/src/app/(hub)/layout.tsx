import PageHeader from "@/components/page-header";
import { Sidebar } from "@/components/sidebar";

export default function HubLayout({ children }: Readonly<{ children: React.ReactNode; }>) {
    return (
        <div className="w-screen min-h-screen flex">
            <Sidebar />
            <div className="p-5 w-full border">
                <PageHeader />
                {children}
            </div>
        </div>
    );
}