interface UserHomeCardProps {
    title: string;
    children: React.ReactNode;
}

export default function UserHomeCard({ title, children }: UserHomeCardProps) {
    return (
        <div className="w-1/2 my-5 bg-slate-100 rounded-md p-4">
            <h2 className="text-2xl font-bold">{title}</h2>
            {/* Add max height and scrolling behavior */}
            <div className="mt-10 flex flex-col gap-y-10 max-h-[700px] overflow-y-auto">
                {children}
            </div>
        </div>
    )
}